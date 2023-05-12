import React, { useEffect, useState } from 'react';
import { Typography, TextField, Paper, IconButton, TableContainer, Table, TableHead, TableBody, TableRow, TableCell, TablePagination } from '@material-ui/core';
import { Search as SearchIcon } from '@material-ui/icons';
import Launch from '../interfaces/Launch';
import '../custom.css';
import LaunchDetails from '../components/LaunchDetails';

const LaunchList = () => {
  const [launches, setLaunches] = useState<Launch[]>([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [launchId, setLaunchId] = useState('');
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const [selectedLaunch, setSelectedLaunch] = useState<string>('');
  const [sortColumn, setSortColumn] = useState<string>('');
  const [sortDirection, setSortDirection] = useState<string>('asc');

  useEffect(() => {
    const fetchLaunches = async () => {
      try {
        const response = await fetch('https://localhost:7124/launches');
        const data = await response.json();
        setLaunches(data);
      } catch (error) {
        console.error('Error fetching launches:', error);
      }
    };

    fetchLaunches();
  }, []);

  const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };

  const filteredLaunches = launches.filter((launch) =>
    launch.mission_Name.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const emptyRows = rowsPerPage - Math.min(rowsPerPage, filteredLaunches.length - page * rowsPerPage);

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleLaunchClick = (flightNumber: string) => {
    setLaunchId(flightNumber);
    setSelectedLaunch(flightNumber);
  };

  const handleChangeRowsPerPage = (event: React.ChangeEvent<HTMLInputElement>) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
  };

  const handleSort = (column: keyof Launch) => {
    if (column === sortColumn) {
      // Toggle the sort direction if the same column is clicked again
      setSortDirection(sortDirection === 'asc' ? 'desc' : 'asc');
    } else {
      // Set the new sort column and reset the sort direction
      setSortColumn(column);
      setSortDirection('asc');
    }
  };
  
  const sortedLaunches = filteredLaunches.sort((a: any, b: any) => {
    const aValue = a[sortColumn];
    const bValue = b[sortColumn];
  
    if (typeof aValue === 'string' && typeof bValue === 'string') {
      if (sortDirection === 'asc') {
        return aValue.localeCompare(bValue);
      } else {
        return bValue.localeCompare(aValue);
      }
    } else {
      // Fallback to basic comparison if values are not strings
      if (sortDirection === 'asc') {
        return aValue < bValue ? -1 : aValue > bValue ? 1 : 0;
      } else {
        return bValue < aValue ? -1 : bValue > aValue ? 1 : 0;
      }
    }
  });

  return (
    <div className="container">
      <div className="launch-list">
        <h1 className="title">SpaceX Launches</h1>
        <div className="searchContainer">
          <TextField
            label="Search"
            value={searchTerm}
            onChange={handleSearchChange}
            className="searchInput"
            InputProps={{
              endAdornment: (
                <IconButton onClick={() => {}}>
                  <SearchIcon />
                </IconButton>
              ),
            }}
          />
        </div>
        <TableContainer component={Paper} className="tableContainer">
          <Table>
            <TableHead>
              <TableRow>
                <TableCell onClick={() => handleSort('flight_Number')}>
                  Flight Number
                </TableCell>
                <TableCell onClick={() => handleSort('mission_Name')}>
                  Mission Name
                </TableCell>
                <TableCell onClick={() => handleSort('launch_Year')}>
                  Launch Year
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {(rowsPerPage > 0
                ? sortedLaunches.slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
                : sortedLaunches
              ).map((launch) => (
                <TableRow
                  key={launch.flight_Number}
                  className={`tableRow ${selectedLaunch === String(launch.flight_Number) ? 'selected' : ''}`}
                  onClick={() => handleLaunchClick(String(launch.flight_Number))}
                >
                  <TableCell>{launch.flight_Number}</TableCell>
                  <TableCell className="link">{launch.mission_Name}</TableCell>
                  <TableCell>{launch.launch_Year}</TableCell>
                </TableRow>
              ))}
              {emptyRows > 0 && (
                <TableRow style={{ height: 53 * emptyRows }} className="emptyRow">
                  <TableCell colSpan={3} />
                </TableRow>
              )}
            </TableBody>
          </Table>
        </TableContainer>
        <div className="pagination">
          <Typography className="paginationText">
            Page: {page + 1} of {Math.ceil(sortedLaunches.length / rowsPerPage)}
          </Typography>
          <TablePagination
            rowsPerPageOptions={[10, 25, 50]}
            component="div"
            count={sortedLaunches.length}
            rowsPerPage={rowsPerPage}
            page={page}
            onPageChange={handleChangePage}
            onRowsPerPageChange={handleChangeRowsPerPage}
          />
        </div>
      </div>
      <div className="launch-details">
        {launchId && <LaunchDetails launchId={launchId} />}
      </div>
    </div>
  );
};

export default LaunchList;


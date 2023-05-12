import React, { useEffect, useState } from 'react';
import { Tabs, Tab } from '@material-ui/core';
import Launch from '../interfaces/Launch';
import '../custom.css';

const LaunchDetails = (props: any) => {
  const id = props.launchId;
  const [launch, setLaunch] = useState<Launch | null>(null);
  const [activeTab, setActiveTab] = useState<number>(0);

  useEffect(() => {
    const fetchLaunchDetails = async () => {
      try {
        const response = await fetch(`https://localhost:7124/launch/${id}`);
        const data = await response.json();
        console.log(data);
        setLaunch(data);
      } catch (error) {
        console.error('Error fetching launch details:', error);
      }
    };

    fetchLaunchDetails();
  }, [id]);

  const handleTabChange = (event: React.ChangeEvent<{}>, newValue: number) => {
    setActiveTab(newValue);
  };

  if (!launch) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1 className="title">Launch Details</h1>
      <div className="launch-details-container">
        <Tabs value={activeTab} onChange={handleTabChange} className="customTabs">
          <Tab label="General" className="customTab" />
          <Tab label="Rocket Details" className="customTab" />
          <Tab label="Payload Details" className="customTab" />
        </Tabs>
        {activeTab === 0 && (
          <div className="details-section">
            <div className="row">
              <span className="label">Flight Number:</span>
              <span className="value">{launch.flight_Number}</span>
            </div>
            <div className="row">
              <span className="label">Mission Name:</span>
              <span className="value">{launch.mission_Name}</span>
            </div>
            <div className="row">
              <span className="label">Upcoming:</span>
              <span className="value">{launch.upcoming ? 'Yes' : 'No'}</span>
            </div>
            <div className="row">
              <span className="label">Launch Year:</span>
              <span className="value">{launch.launch_Year}</span>
            </div>
          </div>
        )}
        {activeTab === 1 && (
          <div className="details-section">
            <div className="row">
              <span className="label">Rocket ID:</span>
              <span className="value">{launch.rocket.rocket_Id}</span>
            </div>
            <div className="row">
              <span className="label">Rocket Name:</span>
              <span className="value">{launch.rocket.rocket_Name}</span>
            </div>
            <div className="row">
              <span className="label">Rocket Type:</span>
              <span className="value">{launch.rocket.rocket_Type}</span>
            </div>
          </div>
        )}
        {activeTab === 2 && (
          <div className="details-section">
            {launch.rocket.second_Stage.payloads.map((payload, index) => (
              <div key={index} className="payload-details">
                <div className="row">
                  <span className="label">Payload ID:</span>
                  <span className="value">{payload.payload_Id}</span>
                </div>
                <div className="row">
                  <span className="label">Payload Type:</span>
                  <span className="value">{payload.payload_Type}</span>
                </div>
              </div>
            ))}
          </div>
        )}
      </div>
    </div>
  );
};

export default LaunchDetails;

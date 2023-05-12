
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import LaunchList from '../src/components/LaunchList';

const App = () => {
  return (
    <Router>
      <div>
        <Routes>
          <Route path="/" element={<LaunchList />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;
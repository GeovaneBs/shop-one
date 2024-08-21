import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import UserList from './components/UserList';
import UserDetail from './components/UserDetail';
import CreateUser from './components/CreateUser';

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route exact path="/" element={<UserList />} />
          <Route path="/user/:id" element={<UserDetail />} />
          <Route path="/create-user" element={<CreateUser />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;

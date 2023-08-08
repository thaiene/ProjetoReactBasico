import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import UserForm from './UserForm';
import UserList from './UserList';


const App = () => {
  return (
    <Router>
      <div className="app-container">
        <h1>Projeto React</h1>
        <Routes>
          <Route path="/" element={<UserList />} />
          <Route path="/users" element={<UserList />} />
          <Route path="/create" element={<UserForm />} />
          <Route path="/edit/:id" element={<UserForm editUser />} />
        </Routes>
      </div>
    </Router>
  );
};

export default App;

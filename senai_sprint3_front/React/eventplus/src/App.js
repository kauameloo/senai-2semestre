import './App.css';
import AppRoutes from './routes/AppRoutes';
import { UserContext } from './context/AuthContext';
import { useState } from 'react';

function App() {
  const [userData, setUserData] = useState({})
  
  return (
    <UserContext.Provider value={{userData, setUserData}}>
    <AppRoutes/>
    </UserContext.Provider>
  );
}

export default App;

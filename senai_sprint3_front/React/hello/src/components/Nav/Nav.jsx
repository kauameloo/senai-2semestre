import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import './Nav.css'
import { ThemeContext } from '../../context/ThemeContext';
const Nav = () => {
    const {theme, setTheme} = useContext(ThemeContext);

    function alterarTema() {
        setTheme( theme === 'light' ? 'dark' : 'light')
    }
    return (
        <div>
            <Link to= "/">Home</Link> | &nbsp;
            <Link to= "/produtos">Produtos</Link> | &nbsp;
            <Link to= "/importante">Importante</Link> | &nbsp;
            <Link to= "/meus-pedidos">Meus Pedidos</Link> | &nbsp;
            <Link to= "/login">Login</Link>
            <button onClick={alterarTema}>{theme}</button>
        </div>
    );
};

export default Nav;
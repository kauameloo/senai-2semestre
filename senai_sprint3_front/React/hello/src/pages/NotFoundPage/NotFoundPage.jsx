import React, { useContext } from 'react';
import './NotFoundPage.css';
import { Link } from 'react-router-dom';
import { ThemeContext } from '../../context/ThemeContext';
const NotFoundPage = () => {
    const {theme} = useContext(ThemeContext)
    return (
        <>
        <h1>
            Página não encontrada
        </h1>
        <Link to="/">Home</Link>
        </>
    );
};

export default NotFoundPage;
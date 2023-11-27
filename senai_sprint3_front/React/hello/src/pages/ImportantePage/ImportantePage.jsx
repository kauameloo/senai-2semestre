import React from 'react';
import './ImportantePage.css'
import { useContext } from 'react';
import { ThemeContext } from '../../context/ThemeContext';
const ImportantePage = () => {
    const {theme} = useContext(ThemeContext)
    return (
        <div>
            <h1>Página de dados importantes</h1>
            <span>Tema Atual: {theme}</span>
        </div>
    );
};

export default ImportantePage;
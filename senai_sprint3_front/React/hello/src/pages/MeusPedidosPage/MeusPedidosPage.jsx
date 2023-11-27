import React, { useContext } from 'react';
import './MeusPedidosPage.css'
import Nav from '../../components/Nav/Nav';
import { ThemeContext } from '../../context/ThemeContext';

const MeusPedidosPage = () => {
    const {theme} = useContext(ThemeContext)
    return (
        <div>
            <span>Tema Atual: {theme}</span>            
        </div>
    );
};

export default MeusPedidosPage;
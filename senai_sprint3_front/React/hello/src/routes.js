import React from 'react';
import HomePage from './pages/HomePage/HomePage';
import LoginPage from './pages/LoginPage/LoginPage';
import ProdutoPage from './pages/ProdutoPage/ProdutoPage';
import { BrowserRouter, Route, Routes } from 'react-router-dom';

const Rotas = () => {
    return (
        <div>
            <BrowserRouter>
                <Routes>
                    <Route element={<HomePage />} path='/' exact/>
                    <Route element={<LoginPage />} path='/login'/>
                    <Route element={<ProdutoPage />} path='/produtos'/>
                </Routes>
            </BrowserRouter>
        </div>
    );
};

export default Rotas;
import React from "react";
import { Route, BrowserRouter, Routes } from "react-router-dom";

// Imports dos componentes - PÁGINAS
import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage";
import NotFoundPage from "./pages/NotFoundPage/NotFoundPage";

// Testar as Rotas
// Context API
// Token
// Login em si

const Rotas = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={ <HomePage /> }  path={"/"} exact />
        <Route element={ <ProdutoPage /> }  path={"/produtos"} />
        <Route element={ <LoginPage /> }  path={"/login"}  />
        <Route element={ <NotFoundPage /> }  path={"*"}  />
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;

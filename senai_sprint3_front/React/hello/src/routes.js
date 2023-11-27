import React, { useState } from "react";
import { Route, BrowserRouter, Routes } from "react-router-dom";

// Imports dos componentes - PÁGINAS
import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage";
import NotFoundPage from "./pages/NotFoundPage/NotFoundPage";
import MeusPedidosPage from "./pages/MeusPedidosPage/MeusPedidosPage";
import ImportantePage from "./pages/ImportantePage/ImportantePage";
import Nav from "./components/Nav/Nav";
import { ThemeContext } from "./context/ThemeContext";

// Testar as Rotas
// Context API
// Token
// Login em si

const Rotas = () => {
  const [theme, setTheme] = useState("light")
  return (
    <BrowserRouter>
      <Nav/>
      <ThemeContext.Provider value={{ theme, setTheme }}>
        <Routes>
          <Route element={<HomePage />} path={"/"} exact />
          <Route element={<ProdutoPage />} path={"/produtos"} />
          <Route element={<ImportantePage />} path={"/importante"} />
          <Route element={<MeusPedidosPage />} path={"/meus-pedidos"} />
          <Route element={<LoginPage />} path={"/login"} />
          <Route element={<NotFoundPage />} path={"*"} />
        </Routes>
        </ThemeContext.Provider>
    </BrowserRouter>
  );
};

export default Rotas;

import Title from "./components/Title/Title";
import CardEvento from "./components/CardEvento/CardEvento";

import Container from "./components/Container/Container";

import "./App.css";
import Contador from "./components/Contador/Contador";
import Rotas from "./routes";
import { ThemeContext } from "./context/ThemeContext";
import { useState } from "react";

function App() {
  // Criar as propriedades titulo, texto, textoLink
  // passar as propriedades em cada um dios 3 componentes abaixo.
  const [theme, setTheme] = useState('light')
  const produtos = [
    {
      idProduto: Math.random(),
      descricao: "Camiseta Regata",
      preco: 49.99,
      promo: false,
    },
    {
      idProduto: Math.random(),
      descricao: "Blusa de Moletom",
      preco: 119.89,
      promo: true,
    },
    {
      idProduto: Math.random(),
      descricao: "Camiseta Regata",
      preco: 49.99,
      promo: false,
    }
  ]
  return (
    <ThemeContext.Provider value={{theme, setTheme, produtos}}>
    <div className={`App ${theme === 'dark' ? 'App-dark' : ''}`}>
      <Rotas />
    </div>
    </ThemeContext.Provider>
  );
}

export default App;

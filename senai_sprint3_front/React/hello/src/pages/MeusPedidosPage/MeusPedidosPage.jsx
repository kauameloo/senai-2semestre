import React, { useContext } from 'react';
import './MeusPedidosPage.css'
import Nav from '../../components/Nav/Nav';
import { ThemeContext } from '../../context/ThemeContext';

const MeusPedidosPage = () => {
    const { theme, produtos } = useContext(ThemeContext)
    let BRL = new Intl.NumberFormat('pt-BR', {
        style: 'currency',
        currency: 'BRL',
    });

    return (
        <>
            <div>
                <h1>Meus Pedidos</h1>
                <span>Tema Atual: {theme}</span>
                <ul style={{ listStyle: 'none' }}>
                    {produtos.map((p) => (
                        <li key={p.idProduto}
                        >
                            <strong>Produto: </strong> {p.descricao} | &nbsp; 
                            <strong>Preço: </strong> {BRL.format(p.preco)} | &nbsp;
                            <strong>Promoção: </strong> {p.promo ? 'SIM' : 'NAO'}
                        </li>
                    ))}
                </ul>
            </div>
        </>
    );
};

export default MeusPedidosPage;
// let BRL = new Intl.NumberFormat('pt-BR', {
//     style: 'currency',
//     currency: 'BRL',
// });


// const convidados = [
//     {nome: "Carlos", idade: 36},
//     {nome: "Claiton", idade: 43},
//     {nome: "Rebeca", idade: 16},
//     {nome: "Magalhaes", idade: 18},
//     {nome: "Lucca", idade: 18},
//     {nome: "Guilherme", idade: 18},
// ]

// const camisaLacoste = {
//     descricao: "Camisa Lacoste",
//     preco: 399.98,
//     marca: "Lacoste",
//     tamanho: "G",
//     cor: "Preto",
//     promo: false
// }

// // const descricao = camisaLacoste.descricao;
// // const preco = camisaLacoste.preco;

// const {descricao, preco, promo} = camisaLacoste;



// console.log(`
//     Produto: ${descricao}
//     Preco: ${BRL.format(preco)}
//     Promoção: ${promo ? "SIM" : "NAO"}
// `);




// Crie um objeto evento com as propriedades
//     DATA EVENTO
//     DESCRIÇÃO DO EVENTO
//     TITULO
//     PRESENÇA
//     COMENTÁRIO

//     Crie uma destructuring das propriedades do objeto evento e as exiba no console

//     OBS: para a presença deve-se exibir "sim" ou "não"

const evento = {
    titulo: "aniversário kallan",
    dataEvento: new Date(2023, 9, 23, 18, 30),
    descricao: "farra, pinga e foguete",
    presenca: true,
    comentario: "ótimo"
}

const {titulo, dataEvento, descricao, ...resto} = evento;

console.log(dataEvento);
console.log(descricao);
console.log(titulo);
console.log(resto);

// console.log(`
//     Titulo: ${titulo.toUpperCase()}
//     Data: ${dataEvento}
//     Descrição: ${descricao}
//     Presenca: ${(presenca ? "Confirmado" : "Não confirmado").toUpperCase()}
//     Comentário: ${comentario}
// `);
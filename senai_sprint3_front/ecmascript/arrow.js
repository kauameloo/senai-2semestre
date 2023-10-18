// const somar = function name(x, y) {
//     return x + y
// }

// const somar = (x, y) => {
//     return x + y;
// }

// const dobro = (numero) => {
//     return numero * 2;
// }

// const dobro = numero => numero * 2;

// console.log(dobro(10));
// console.log( somar(50, 10));

// const boaTarde = () => { console.log("Boa Tarde!"); }

// boaTarde();

const convidados = [
    {nome: "Carlos", idade: 36},
    {nome: "Claiton", idade: 43},
    {nome: "Rebeca", idade: 16},
    {nome: "Magalhaes", idade: 18},
    {nome: "Lucca", idade: 18},
    {nome: "Guilherme", idade: 18},
]

const listar = () => convidados.forEach((c, i) => {
    console.log(`
    ${i + 1}) Nome: ${c.nome} 
        Idade: ${c.idade}`);
});
console.log("Pessoas convidadas:");
listar();
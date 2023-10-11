let eduardo = {
    nome: "Eduardo",
    idade: 41,
    altura: 1.67
};

eduardo.peso = 89;

let carlos = new Object();

carlos.nome = "Carlos";
carlos.idade = 36;
carlos.sobrenome = "Roque";


let pessoas = [];

pessoas.push(carlos);
pessoas.push(eduardo);
// exibir os nomes das pessoas utilizando o foreach


// => é a mesma coisa que o function
pessoas.forEach((f, i) => {
    console.log(`Pessoa ${i + 1}: Nome - ${f.nome}, Idade - ${f.idade}`);
})
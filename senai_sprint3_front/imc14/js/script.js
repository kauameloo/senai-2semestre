function calcular(event) {
    event.preventDefault();


    // CRIANDO O OBJETO PESSOA QUE VAI SER CADASTRADO
    let pessoa = {}

    pessoa.nome = document.getElementById("nome").value.trim();
    pessoa.altura = parseFloat(document.getElementById("altura").value);
    pessoa.peso = parseFloat(document.getElementById("peso").value)
    // pessoa.imc = (pessoa.peso / (pessoa.altura ** 2)).toFixed(2);
    pessoa.imc = calcularImc(pessoa.peso, pessoa.altura).toFixed(2);
    pessoa.situacao = geraSituacao(pessoa.imc);


    // VERIFICAÇÃO DOS CAMPOS
    if (isNaN(pessoa.altura) || isNaN(pessoa.peso) || pessoa.nome.length < 2) {
        alert('É necessário preencher todos os campos.')
        return;
    }

    // CRIANDO A LISTA DE PESSOAS E ADICIONANDO O OBJETO NELA
    let arrayPessoas = [];
    arrayPessoas.push(pessoa);

    // ADICIONANDO, NA TABELA HTML, A LISTA DE PESSOAS
    let tbody = document.getElementById("cadastro");
    for (let i = 0; i < arrayPessoas.length; i++) {
        let tr = tbody.insertRow();

        // CRIANDO AS COLUNAS
        let td_nome = tr.insertCell();
        let td_altura = tr.insertCell();
        let td_peso = tr.insertCell();
        let td_imc = tr.insertCell();
        let td_situacao = tr.insertCell();

        // INSERINDO OS VALORES DE CADA PESSOA DA LISTA EM SUAS RESPECTIVAS COLUNAS
        td_nome.innerText = arrayPessoas[i].nome.toUpperCase();
        td_altura.innerText = arrayPessoas[i].altura;
        td_peso.innerText = arrayPessoas[i].peso;
        td_imc.innerText = arrayPessoas[i].imc;
        td_situacao.innerText = arrayPessoas[i].situacao.toUpperCase();
    }

}

function calcularImc(peso, altura) {
    return peso / (altura ** 2);
}

function geraSituacao(imc) {
    // VERIFICAÇÃO DA SITUAÇÃO
    if (imc < 18.5) {
        situacao = "Baixo peso"
    }
    else if (imc >= 18.5 && imc <= 24.99) {
        situacao = "Peso normal"
    }
    else if (imc >= 25 && imc <= 29.99) {
        situacao = "Sobrepeso"
    }
    else {
        situacao = "Obesidade"
    }

    return situacao;
}
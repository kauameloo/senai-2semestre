
const urlLocal = "http://localhost:3000/contatos";

async function chamarApi() {
    const userCEP = document.getElementById("cep").value;
    const url = `https://viacep.com.br/ws/${userCEP}/json/`;

    try {
        const promise = await fetch(url);
        const dados = await promise.json();

        exibeDados(dados);

        console.log(dados);

        function exibeDados(dados) {
            document.getElementById("rua").value = dados.logradouro;
            document.getElementById("bairro").value = dados.bairro;
            document.getElementById("cidade").value = dados.localidade;
            document.getElementById("UF").value = dados.uf;
            // document.getElementById("ddd").value = dados.ddd;
        }

    } catch (error) {
        console.log("Erro no API");
        // alert("CEP Inválido");

        // apagaEndereco();
    }
}

// function apagaEndereco() {
//     document.getElementById("rua").value = "";
//     document.getElementById("bairro").value = "";
//     document.getElementById("cidade").value = "";
//     document.getElementById("uf").value = "";
// }

    async function cadastrar(e) {
        e.preventDefault();

        const nome = document.getElementById("nome").value;
        const sobrenome = document.getElementById("sobrenome").value;
        const email = document.getElementById("email").value;
        const pais = document.getElementById("pais").value;
        const ddd = document.getElementById("ddd").value;
        const telefone = document.getElementById("telefone").value;
        const cep = document.getElementById("cep").value;
        const rua = document.getElementById("rua").value;
        const numero = document.getElementById("numero").value;
        const complemento = document.getElementById("complemento").value;
        const bairro = document.getElementById("bairro").value;
        const cidade = document.getElementById("cidade").value;
        const uf = document.getElementById("UF").value;
        const anotacoes = document.getElementById("anotacoes").value;

        const objDados = {nome, sobrenome, email, pais, ddd, telefone, cep, rua, numero, complemento, bairro, cidade, uf, anotacoes}

        try {
            const promise = await fetch(urlLocal, {
                body : JSON.stringify(objDados),
                headers : {"Content-Type" : "application/json"},
                method : "post"
            });

            const retorno = await promise.json(); 
            console.log(retorno);

        } catch (error) {
            alert("Erro: " + error)
        }
    }


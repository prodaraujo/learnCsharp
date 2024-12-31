const URL = "http://localhost:5138";  // URL base da API

// Função comum para tratar as requisições e exibir os dados
async function fetchData(url, method = "GET", body = null) {
    try {
        const options = {
            method,
            headers: {
                "Content-Type": "application/json",
            },
            body: body ? JSON.stringify(body) : null,
        };

        const response = await fetch(url, options);
        if (!response.ok) {
            throw new Error(`Erro: ${response.statusText}`);
        }

        const data = await response.json();  // Converte a resposta em JSON
        console.log("Dados recebidos:", data);

        // Exibe os dados na página
        const resultadoDiv = document.getElementById('resultado');
        if (data.length === 0) {
            resultadoDiv.innerHTML = "<strong>Nenhum dado encontrado.</strong>";
        } else {
            let resultadoHTML = '<ul>';
            data.forEach(item => {
                resultadoHTML += `<li>ID: ${item.id} - Nome: ${item.nome} - Telefone: ${item.telefone} - E-mail: ${item.email}</li>`;
            });
            resultadoHTML += '</ul>';
            resultadoDiv.innerHTML = resultadoHTML;
        }
    } catch (error) {
        console.error("Erro ao buscar dados:", error);
        document.getElementById('resultado').innerHTML = "<strong>Erro ao carregar os dados.</strong>";
    }
}

// Funções específicas para cada método HTTP

async function GET() {
    await fetchData(URL+"/Ler", "GET");  // Chama a função comum para GET
}

async function POST() {
    // Captura os dados do formulário POST
    const nome = document.getElementById('nome').value;
    const telefone = document.getElementById('telefone').value;
    const email = document.getElementById('email').value;

    if (!nome || !telefone || !email) {
        alert("Por favor, preencha todos os campos.");
        return;
    }

    const newData = {
        nome,
        telefone,
        email
    };
    await fetchData(URL+"/Adicionar", "POST", newData);  // Chama a função comum para POST com dados
}

async function PUT() {
    // Captura os dados do formulário PUT
    const id = document.getElementById('idUpdate').value;
    const nome = document.getElementById('nomeUpdate').value;
    const telefone = document.getElementById('telefoneUpdate').value;
    const email = document.getElementById('emailUpdate').value;

    if (!id || !nome || !telefone || !email) {
        alert("Por favor, preencha todos os campos.");
        return;
    }

    const updatedData = {
        id,
        nome,
        telefone,
        email
    };
    await fetchData(`${URL}/Alterar/${id}`, "PUT", updatedData);  // Chama a função comum para PUT com dados
}

async function DELETE() {
    // Captura o ID do cliente a ser deletado
    const id = document.getElementById('idDelete').value;

    if (!id) {
        alert("Por favor, forneça o ID do cliente.");
        return;
    }

    await fetchData(`${URL}/Excluir/${id}`, "DELETE");  // Chama a função comum para DELETE
}

const URL = "http://localhost:5138/Ler";

async function fetchGET() {
    const resp = await fetch(URL);
    const dados = await resp.json();
    document.getElementById('resultado').innerHTML = dados.map(item => 
        `<p>ID: ${item.id} - Nome: ${item.nome} - Telefone: ${item.telefone}</p>`
    ).join('');
}
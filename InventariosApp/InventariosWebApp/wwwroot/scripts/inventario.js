async function cargar() {
    const res = await fetch('/api/inventario');
    const datos = await res.json();
    document.getElementById('listaInventario').innerHTML = datos.map(a => `<li class="list-group-item list-group-item-info">${a.nombre}: ${a.categoria} - $${a.precio}. Actualmente hay ${a.cantidad}</li>`).join('');
}

async function limpiar() {
    const formulario = document.getElementById('formInventario');
    formulario.reset();
    document.getElementById('txtNombre').focus();
}

async function agregar() {
    const nombre = document.getElementById('txtNombre').value;
    const precio = document.getElementById('txtPrecio').value;
    const idCategoria = document.getElementById('cmbCategoria').value;
    const cantidad = document.getElementById('txtCantidad').value;
    await fetch('/api/inventario', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ nombre, precio, idCategoria, cantidad })
    });
    cargar();
    limpiar();
}
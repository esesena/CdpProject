// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function mask() {
    $('#cpf').mask('000.000.000-00', { reverse: true });
    $('#cnpj').mask('00.000.000/0000-00', { reverse: true });
    $('#cep').mask('00000-000');
};
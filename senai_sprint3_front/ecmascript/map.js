// foreach - void

// map - novo array modificado
    // const numeros = [1, 2, 5, 10, 300];

    // const dobro = numeros.map( (n) => {
    //     return n * 2;
    // });

// filter - novo array apenas com elementos que atenderam uma condição
    // const numeros = [1, 2, 5, 10, 300];

    // const dobro = numeros.filter( (e) => {
    //     return e > 10;
    // });

// reduce
const comentarios = [
    {comentario: "bla bla bla", exibe: true}, 
    {comentario: "evento otimo", exibe: true},
    {comentario: "evento ruim", exibe: false} 
]

const comentariosOk = comentarios.filter((c) => {
    return c.exibe == true;
    // return c.exibe;
})

comentariosOk.forEach((c) => {
    console.log(c.comentario);
})
import React, { useEffect, useState } from "react";
import Title from "./../../components/Title/Title";
import MainContent from "./../../components/MainContent/MainContent";
import "./TipoEventosPage.css"
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import eventTypeImage from '../../assets/images/tipo-evento.svg'
import Container from "../../components/Container/Container";
import { Input } from "../../components/FormComponents/FormComponents";
import { Button } from "../../components/FormComponents/FormComponents";
import api from '../../Services/Service'
import TableTp from "./TableTp/TableTp";

const TipoEventosPage = () => {

  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  const [tipoEventos, setTipoEventos] = useState([
  ]);

  async function handleSubmit(e) {
    //parar o submit do formulário
    e.preventDefault();
    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      alert("O Título deve ter no mínimo 3 carácteres");
      return;
    }
    //chamar api
    try {
      const retorno = await api.post('/TiposEvento', { titulo: titulo })
      console.log("CADASTRADO COM SUCESSO");
      console.log(retorno.data);

    } catch (error) {
      console.log('Deu ruim na api');
      console.log(error);
    }
  }

  useEffect(() => {
    async function getTitulos() {
      try {
        const promise = await api.get("/TiposEvento")
        setTipoEventos(promise.data)
      } catch (error) {
        console.error("Erro ao carregar tipos de evento: " + error)        
      }
    }
    
    getTitulos()
  }, [tipoEventos])

  //ATUALIZAÇÃO DOS DADOS
  function showUpdateForm() {
    alert('Mostrando a tela de update')
  }

  function handleUpdate() {
    alert("Bora atualizar")
  }

  function editActionAbort() {
    alert("Cancelar a tela de edição")
  }


  function handleDelete() {
    alert('Bora lá apagar na api')
  }

  return (
    <MainContent>
      {/* Cadastro de tipo de eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} additionalClass="margem-acima" />
            <ImageIllustrator
              alterText={'??????'}
              imageRender={eventTypeImage}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}>

              {!frmEdit ?
                (
                  <>
                    <Input
                      type={"text"}
                      id={"titulo"}
                      name={"titulo"}
                      required={"required"}
                      placeholder={"Título"}
                      value={titulo}
                      manipulationFunction={
                        (e) => {
                          setTitulo(e.target.value)
                        }
                      }
                    />
                    <Button
                      type={"submit"}
                      name={"cadastrar"}
                      id={"cadastrar"}
                      textButton={"Cadastrar"}
                    />
                  </>
                )

                :

                (<p>Tela de Edição</p>)
              }

            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de tipo de eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={'Lista Tipo de Eventos'} color="white" />
          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>

    </MainContent>
  );
};

export default TipoEventosPage;

import React, { useEffect, useState } from "react";
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent";
import api from "../../Services/Service";
import Spinner from "../../components/Spinner/Spinner";
import Notification from "../../components/Notification/Notification";
import { Input, Button, SelectTipo, SelectInst } from "../../components/FormComponents/FormComponents";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import Container from "../../components/Container/Container";
import TableEp from "./TableEp/TableEp";
import eventImage from "../../assets/images/evento.svg";
import dateFormatDbToView from "../../Utils/stringFunction";

const EventosPage = () => {
  //
  const [frmEdit, setFrmEdit] = useState(false);

  const [nomeEvento, setTitulo] = useState("");
  const [descricao, setDescricao] = useState("");
  const [dataEvento, setDataEvento] = useState("");
  const [idTipoEvento, setIdTipoEvento] = useState("");
  const [idInstituicao, setIdInstituicao] = useState("");
  const [instituicaoPadrao, setInstituicaoPadrao] = useState("");

  const [evento, setEvento] = useState([]);
  const [tiposEvento, setTiposEvento] = useState([]);
  const [instituicao, setInstituicao] = useState([]);

  const [idEvento, setIdEvento] = useState("");

  const [notifyUser, setNotifyUser] = useState({});

  const [showSpinner, setShowSpinner] = useState(false);



  //chamar a api
  async function getTitulos() {
    setShowSpinner(true);
    try {
      const promise = await api.get("https://localhost:7118/api/TiposEvento");
      setTiposEvento(promise.data);
    } catch (error) {
      console.log("Erro ao carregar tipos de evento: " + error);
    }
    setShowSpinner(false);
  }





  //chamar a api
  async function getInstituicao() {
    setShowSpinner(true);
    try {
      const promise = await api.get("https://localhost:7118/api/Instituicao");
      const dadosInstituicao = promise.data;

      // PEGAR O PRIMEIRO VALOR DA ARRAY DE INSTITUIÇÃO
      setInstituicaoPadrao(dadosInstituicao[0].idInstituicao);
      //

      setInstituicao(dadosInstituicao);
    } catch (error) {
      console.log("Erro ao carregar instituições: " + error);
    }
    setShowSpinner(false);
  }



  async function getEvento() {
    setShowSpinner(true);
    try {
      const promise = await api.get("https://localhost:7118/api/Evento");
      setEvento(promise.data);
    } catch (error) {
      console.log("Erro ao carregar eventos: " + error);
    }
    setShowSpinner(false);
  }
  useEffect(() => {
    //chamar a api
    getInstituicao();
    getTitulos();
    getEvento();
  }, []);

  //CADASTRAR EVENTO

  async function handleSubmit(e) {
    e.preventDefault();
    setShowSpinner(true);
    // parar o submit do formulário
    // validar pelo menos 3 caracteres
    //chamar a api

    if (nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Nome inválido",
        textNote: `digite pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de aviso. Moça pisando em um símbolo de exclamação.",
        showMessage: true,
      });
      return;
    }
    //chamar a api
    try {
      const promise = await api.post("https://localhost:7118/api/Evento", { nomeEvento: nomeEvento, descricao: descricao, idTipoEvento: idTipoEvento, idInstituicao: idInstituicao, dataEvento: dataEvento });
      getEvento();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      console.error(error + "Erro ao cadastrar evento");
    }

    //limpar o formulário
    setTitulo("");
    setDescricao("");
    setDataEvento("");
    setIdTipoEvento("");
    setIdInstituicao("");
    setShowSpinner(false);
  }

  //MOSTRAR FORMULÁRIO DE EDIÇÃO

  function showUpdateForm(evento) {
    setFrmEdit(true);
    setTitulo(evento.nomeEvento);
    setDescricao(evento.descricao);
    setDataEvento(evento.dataEvento.substr(0, 10));
    setIdTipoEvento(evento.idTipoEvento);
    setIdInstituicao(evento.idInstituicao);

    setIdEvento(evento.idEvento);
  }


  // ATUALIZAR EVENTO
  async function handleUpdate(e) {
    e.preventDefault();
    setShowSpinner(true);

    if (nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Nome inválido",
        textNote: `Digite pelo menos 3 caracteres!`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de aviso. Moça pisando em um símbolo de exclamação.",
        showMessage: true,
      });
      return;
    }

    try {
      const promise = await api.put(`https://localhost:7118/api/Evento/${idEvento}`, {
        nomeEvento: nomeEvento, descricao: descricao, idTipoEvento: idTipoEvento, idInstituicao: idInstituicao, dataEvento: dataEvento
      });
      getEvento();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Atualizado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      setTitulo("");
      setDescricao("");
      setDataEvento("");
      setIdTipoEvento("");
      setIdInstituicao("");
      setFrmEdit(false);
    } catch (error) {
      console.error("Erro ao atualizar evento: " + error);
    }

    setShowSpinner(false);
  }

  function cancelUpdate() {
    //limpar o formulário
    setTitulo("");
    setDescricao("");
    setDataEvento("");
    setIdTipoEvento("");
    setIdInstituicao("");
    setFrmEdit(false);
  }


  // DELETAR EVENTO
  async function handleDelete(id) {
    setShowSpinner(true);
    try {
      evento.filter((evento) => evento.idEvento === id);
      const promise = await api.delete(`https://localhost:7118/api/Evento/${id}`);
      getEvento();
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Deletado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      console.error("Erro ao deletar evento: " + error);
    }
    setShowSpinner(false);
  }

  return (
    <MainContent>
      {/* Cadastro de eventos */}
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title
              titleText={"Página de Eventos"}
              additionalClass="margem-acima"
            />

            <ImageIllustrator alterText="??????" imageRender={eventImage} />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
              action=""
            >
              {!frmEdit ? (
                <>
                  <Input
                    id="nomeEvento"
                    placeholder="Título"
                    type="text"
                    name="nomeEvento"
                    value={nomeEvento}
                    required
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <Input
                    id="descricao"
                    placeholder="Descrição"
                    type="text"
                    name="descricao"
                    value={descricao}
                    required
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />
                  <Input
                    id="dataEvento"
                    placeholder="dataEvento"
                    type="date"
                    name="descricao"
                    value={dataEvento}
                    required
                    manipulationFunction={(e) => {
                      setDataEvento(e.target.value);
                    }}
                  />
                  <SelectTipo
                    dados={tiposEvento}
                    id="idTipoEvento"
                    placeholder="Tipo do Evento"
                    name="idTipoEvento"
                    value={idTipoEvento}
                    required
                    manipulationFunction={(e) => {
                      setIdTipoEvento(e.target.value);
                    }}
                  />
                  <SelectInst
                    dados={instituicao}
                    id="idInstituicao"
                    placeholder="idInstituicao"
                    name="idInstituicao"
                    value={idInstituicao}
                    required
                    manipulationFunction={(e) => {
                      setIdInstituicao(e.target.value);
                    }}
                  />
                  <Button
                    id="cadastrar"
                    type="submit"
                    name="cadastrar"
                    textButton="Cadastrar"
                  />
                </>
              ) : (
                <>
                  <p>Tela de Edição</p>
                  <Input
                    id="nomeEvento"
                    placeholder="Título"
                    type="text"
                    name="nomeEvento"
                    value={nomeEvento}
                    required
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <Input
                    id="descricao"
                    placeholder="Descrição"
                    type="text"
                    name="descricao"
                    value={descricao}
                    required
                    manipulationFunction={(e) => {
                      setDescricao(e.target.value);
                    }}
                  />
                  <Input
                    id="dataEvento"
                    placeholder="dataEvento"
                    type="date"
                    name="descricao"
                    value={dataEvento}
                    required
                    manipulationFunction={(e) => {
                      setDataEvento(e.target.value);
                    }}
                  />
                  <SelectTipo
                    dados={tiposEvento}
                    id="idTipoEvento"
                    placeholder="Tipo do Evento"
                    type="number"
                    name="idTipoEvento"
                    value={idTipoEvento}
                    required
                    manipulationFunction={(e) => {
                      setIdTipoEvento(e.target.value);
                    }}
                  />
                  <SelectInst
                    dados={instituicao}
                    id="idInstituicao"
                    placeholder="idInstituicao"
                    name="idInstituicao"
                    value={idInstituicao}
                    required
                    manipulationFunction={(e) => {
                      setIdInstituicao(e.target.value);
                    }}
                  />
                  <div className="buttons-editbox">
                    <Button
                      id="editar"
                      type="submit"
                      name="editar"
                      textButton="Editar"
                    />
                    <Button
                      id="cancelar"
                      type="reset"
                      manipulationFunction={cancelUpdate}
                      additionalClass="button-component--middle"
                      name="cancelar"
                      textButton="Cancelar"
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/* Listagem de tipo de eventos */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Eventos"} color="white" />

          <TableEp
            dados={evento}
            fnDelete={handleDelete}
            fnUpdate={showUpdateForm}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;

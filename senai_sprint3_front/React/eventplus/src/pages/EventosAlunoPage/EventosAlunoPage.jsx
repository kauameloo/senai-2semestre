import React, { useContext, useEffect, useState } from "react";
import Header from "../../components/Header/Header";
import MainContent from "../../components/MainContent/MainContent";
import Title from "../../components/Title/Title";
import Table from "./TableEva/TableEva";
import Container from "../../components/Container/Container";
import { Select, SelectA } from "../../components/FormComponents/FormComponents";
import Spinner from "../../components/Spinner/Spinner";
import Modal from "../../components/Modal/Modal";
import api from "../../Services/Service";


import "./EventosAlunoPage.css";
import { userContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState(1); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(userContext);

  useEffect(() => {
    async function loadEventsType() {
        setShowSpinner(true);
        try {
            if (tipoEvento === "1") {
                const promise = await api.get("https://localhost:7118/api/Evento")
                const promiseEventos = await api.get(`https://localhost:7118/api/PresencasEvento/ListarMinhas/${userData.userId}`) 

                const dadosMarcados = verificaPresenca(promise.data, promiseEventos.data)
                console.clear();
                console.log("Dados marcados:");
                console.log(dadosMarcados);

                setEventos(promise.data);

            } else {
                let arrayEvento = [];
                const promiseEventos = await api.get(`https://localhost:7118/api/PresencasEvento/ListarMinhas/${userData.userId}`) 
                // setEventos(promiseEventos.data)
                promiseEventos.data.forEach((element) => {
                  arrayEvento.push(element.evento);
                  setEventos(arrayEvento);
                })
                console.log(arrayEvento);
            }
        } catch (error) {
            console.log("Erro ao carregar os eventos");
        }
        setShowSpinner(false);
    }
    

    loadEventsType();
  }, [tipoEvento]);


const verificaPresenca = (arrAllEvents, eventsUser) => {
  for (let x = 0; x < arrAllEvents.length; x++) { // PARA CADA EVENTO (TODOS)

    // VERIFICA SE O ALUNO ESTÁ PARTICIPANDO DO EVENTO ATUAL (x)
    for (let i = 0; i < eventsUser.length; i++) { //VERIFICA EM MEUS EVENTOS

      if(arrAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
        arrAllEvents[x].situacao = true;
        break;
      } 
    }
  }
  //devolve array modificado
  return arrAllEvents;
}

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
  }
  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <SelectA
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            value={tipoEvento}
            className="select-tp-evento"
          />
          <Table
            object={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;

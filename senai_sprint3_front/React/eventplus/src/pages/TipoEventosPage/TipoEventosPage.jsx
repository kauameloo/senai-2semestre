import React, { useState } from "react";
import Title from "./../../components/Title/Title";
import MainContent from "./../../components/MainContent/MainContent";
import "./TipoEventosPage.css"
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import eventTypeImage from '../../assets/images/tipo-evento.svg'
import Container from "../../components/Container/Container";
import { Input } from "../../components/FormComponents/FormComponents";
const TipoEventosPage = () => {

  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} additionalClass="margem-acima" />
            <ImageIllustrator
              alterText={'??????'}
              imageRender={eventTypeImage}
            />

            <form action="">
              <p>Componente de Formulário</p>
              <Input
              value={"Eduardo"}
              type={"text"}
              required={"required"}
              />
            </form>
          </div>
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;

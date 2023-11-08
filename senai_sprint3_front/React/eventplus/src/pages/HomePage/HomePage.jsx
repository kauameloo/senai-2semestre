import React from "react";
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container"

const HomePage = () => {
  return (
    <MainContent>
      <Banner />
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"HomePage"} additionalClass="margem-acima" />

          <div className="events-box">
            <NextEvent
              title={"Happy Hour Event"}
              description={"Evento legal"}
              eventDate={"14/11/2023"}
              idEvento={"1209381ad12i"}
            />
          </div>
        </Container>
      </section>


      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;

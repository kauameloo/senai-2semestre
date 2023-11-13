import React, { useEffect, useState, useRef } from "react";
import Title from "../../components/Title/Title";
import MainContent from "../../components/MainContent/MainContent";
import Banner from "../../components/Banner/Banner";
import VisionSection from "../../components/VisionSection/VisionSection";
import ContactSection from "../../components/ContactSection/ContactSection";
import NextEvent from "../../components/NextEvent/NextEvent";
import Container from "../../components/Container/Container"
import axios from "axios";
import api from "../../Services/Service";

// Import Swiper React components
import { Swiper, SwiperSlide } from 'swiper/react';

// Import Swiper styles
import 'swiper/css';
import 'swiper/css/pagination';

import './HomePage.css';

// import required modules
import { Pagination } from 'swiper/modules';


const HomePage = () => {

  useEffect(() => {
    //chamar a api
    async function getProximosEventos() {
      try {
        const promise = await api.get("https://localhost:7118/api/Evento/ListarProximos")

        console.log(promise.data);
        setNextEvents(promise.data)
      } catch (error) {
        console.log("Deu ruim na API");
      }
    }
    getProximosEventos();
  }, [])

  //fake mock - api mocada
  const [nextEvents, setNextEvents] = useState([]);

  return (
    <MainContent>
      <Banner />
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"HomePage"} additionalClass="margem-acima" />

          <div className="events-box">

              <Swiper
                pagination={{
                  dynamicBullets: true,
                }}
                modules={[Pagination]}
                className="mySwiper"
                >
                {
                  nextEvents.map((e) => {
                    return (
                      <>

                      <SwiperSlide>


                        <NextEvent
                          key={e.idEvento}
                          title={e.nomeEvento}
                          description={e.descricao}
                          eventDate={e.dataEvento.replace("T00:00:00", "")}
                          idEvento={e.idEvento}
                        />

                      </SwiperSlide>

</>
                    )
                  })
                }


              </Swiper>
            </div >
        </Container>
      </section>


      <VisionSection />
      <ContactSection />
    </MainContent>
  );
};

export default HomePage;

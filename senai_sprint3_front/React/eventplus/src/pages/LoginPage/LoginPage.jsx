import React, { useContext, useState } from "react";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import loginImage from "../../assets/images/login.svg"  
import "./LoginPage.css";
import api from "../../Services/Service";
import { UserContext, userDecodeToken } from "../../context/AuthContext";

const LoginPage = () => {
  const [user, setUser] = useState({email: "kauazin@email.com", senha: "kauazin123"});

  const {userData, setUserData} = useContext(UserContext)
  async function handleSubmit(e) {
    e.preventDefault();
    console.log(user);

    if (user.email.length > 3 && user.senha.length > 3) {
      //chamar a api
      try {
        const promise = await api.post("https://localhost:7118/api/Login", { email: user.email, senha: user.senha })

        console.log(promise.data.token);

        const userFullToken = userDecodeToken(promise.data.token)
        setUserData(userFullToken)
      } catch (error) {
        alert("Usuário ou senha inválidos ou conexão com a internet finalizada")
      }
    } else {
      alert("Preencha os campos corretamente")
    }
  }

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={loginImage}
            altText="Imagem de um homem em frente de uma porta de entrada"
            className="login-illustrator "
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                setUser({
                  ...user,
                  email: e.target.value.trim()})
               }}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => { 
                setUser({
                  ...user,
                  senha: e.target.value.trim()})
              }}
              placeholder="****"
            />

            <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button "
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;

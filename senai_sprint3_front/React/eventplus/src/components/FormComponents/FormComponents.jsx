import React from "react";
import "./FormComponents.css";




export const Input = ({
  type,
  id,
  value,
  required,
  additionalClass = "",
  name,
  placeholder,
  manipulationFunction,
}) => {
  return (
    <input
      type={type}
      id={id}
      value={value}
      required={required}
      className={`input-component ${additionalClass}`}
      name={name}
      placeholder={placeholder}
      onChange={manipulationFunction}
      autoComplete="off"
    />
  );
};

export const SelectTipo = ({
  dados,
  id,
  value,
  required,
  additionalClass = "",
  name,
  placeholder,
  manipulationFunction,
}) => {
  return (
    <select
      id={id}
      value={value}
      required={required}
      className={`input-component ${additionalClass}`}
      name={name}
      placeholder={placeholder}
      onChange={manipulationFunction}
    >
      <option value="">Selecione o Tipo</option>
      {dados.map((opcao) => (
        <option key={opcao.idTipoEvento} value={opcao.idTipoEvento}>{opcao.titulo}</option>
      ))}

    </select>
  );
};

export const SelectInst = ({
  dados,
  id,
  value,
  required,
  additionalClass = "",
  name,
  placeholder,
  manipulationFunction,
}) => {
  return (
    <select
      id={id}
      value={value}
      required={required}
      className={`input-component ${additionalClass}`}
      name={name}
      placeholder={placeholder}
      onChange={manipulationFunction}
    >
      <option value="">Selecione a Instituicao</option>
      {dados.map((opcao) => (
        <option key={opcao.idInstituicao} value={opcao.idInstituicao}>{opcao.nomeFantasia}</option>
      ))}

    </select>
  );
};

export const Button = ({
  type,
  id,
  name,
  additionalClass = "",
  textButton,
  manipulationFunction,
}) => {
  return <button onClick={manipulationFunction} type={type} name={name} id={id} className={`button-component ${additionalClass}`}>
    {textButton}
  </button>;
};

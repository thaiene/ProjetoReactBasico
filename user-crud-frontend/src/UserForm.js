import React, { useState, useEffect } from 'react';
import { createUser, updateUser, getUser } from './api';
import { useNavigate, useParams } from 'react-router-dom';
import InputMask from 'react-input-mask'

const UserForm = ({ onUserCreated, editUser }) => {
  const [formData, setFormData] = useState({
    nome: '',
    email: '',
    telefone: '',
    senha: '',
  });
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();
  const { id } = useParams();
  const userId = id ?? ''; // Define um valor padrão vazio caso o id não exista na URL

  useEffect(() => {
    const loadUser = async () => {
      try {
        const response = await getUser(userId);
        const user = response.data;
        setFormData(user);
        setLoading(false);
      } catch (error) {
        console.error('Error fetching user:', error);
        setLoading(false);
      }
    };
  
    if (editUser) {
      loadUser();
    } else {
      setLoading(false);
    }
  }, [editUser, userId]);  

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      if (editUser) {
        await updateUser(userId, formData);
      } else {
        await createUser(formData);
      }

      navigate('/');
    } catch (error) {
      console.error('Error submitting form:', error);
    }
  };

  return (
    <div className="user-form">
      {loading ? (
        <p>Carregando usuário...</p>
      ) : (
        <>
          <h2>{editUser ? 'Editar Usuário' : 'Cadastrar Usuário'}</h2>
          <form onSubmit={handleSubmit}>
            <input
              type="text"
              name="nome"
              value={formData.nome}
              onChange={handleInputChange}
              placeholder="Nome"
              required
            />
            <input
              type="email"
              name="email"
              value={formData.email}
              onChange={handleInputChange}
              placeholder="Email"
              required
            />            
            <InputMask
              mask="(99) 9999-9999"
              name="telefone"
              value={formData.telefone}
              onChange={handleInputChange}
              placeholder="Telefone"
            ></InputMask>
            <input
              type="password"
              name="senha"
              value={formData.senha}
              onChange={handleInputChange}
              placeholder="Senha"
              required
            />
            <button type="submit">Salvar</button>
            <button type="button" onClick={() => navigate('/')}>
              Ver Lista
            </button>
          </form>
        </>
      )}
    </div>
  );
};

export default UserForm;

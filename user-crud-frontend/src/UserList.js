import React, { useState, useEffect } from 'react';
import { getUsers, deleteUser } from './api';
import { Link, useNavigate } from 'react-router-dom';

const UserList = () => {
    const [users, setUsers] = useState([]);
    const navigate = useNavigate(); // Hook useNavigate para navegar entre as rotas

    useEffect(() => {
        fetchUsers();
      }, []);

    const fetchUsers = async () => {
      try {
        const response = await getUsers();
        setUsers(response.data);
      } catch (error) {
        console.error('Erro ao buscar usuários:', error);
      }
    };

    const handleEditUser = async (user) => {
        navigate(`/edit/${user.id}`); // Navega para a rota de edição com o ID do usuário
    };

    const handleDeleteUser = async (id) => {
        try {
          await deleteUser(id);
          fetchUsers();
        } catch (error) {
          console.error('Erro ao excluir usuário:', error);
        }
      };

    return (
    <div className="user-list">
      <h2>Lista de Usuários</h2>
      {users.length === 0 ? (
        <p>Não existem usuários cadastrados!</p>
      ) : (
        <table>
          <thead>
            <tr>
              <th>Nome</th>
              <th>Email</th>
              <th>Telefone</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {users.map((user) => (
              <tr key={user.id}>
                <td>{user.nome}</td>
                <td>{user.email}</td>
                <td>{user.telefone}</td>
                <td className="user-actions">
                    <button className="user-edit-button" onClick={() => handleEditUser(user)}>Editar</button>
                    <button className="user-delete-button" onClick={() => handleDeleteUser(user.id)}>Excluir</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
      <div className="user-create-button">
        <Link to="/create">
          <button>Criar Usuário</button>
        </Link>
      </div>
    </div>
  );
};

export default UserList;
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

function UserDetail() {
  const { id } = useParams();
  const [user, setUser] = useState(null);

  useEffect(() => {
    axios.get(`${process.env.REACT_APP_API_URL}/api/User/${id}`)
      .then(response => setUser(response.data))
      .catch(error => console.error('Error fetching user:', error));
  }, [id]);

  if (!user) {
    return <div>Carregando...</div>;
  }

  return (
    <div>
      <h1>Detalhes do Usuário</h1>
      <p>Nome: {user.name}</p>
      <p>Email: {user.email}</p>
    </div>
  );
}

export default UserDetail;

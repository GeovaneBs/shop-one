import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function CreateUser() {
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const navigate = useNavigate(); // Substitua useHistory por useNavigate

  const handleSubmit = (event) => {
    event.preventDefault();

    axios.post(`${process.env.REACT_APP_API_URL}/api/User`, { name, email, password })
      .then(response => {
        console.log('User created:', response.data);
        navigate('/'); // Use navigate ao invés de history.push
      })
      .catch(error => console.error('Error creating user:', error));
  };

  return (
    <div>
      <h1>Criar Novo Usuário</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Nome:</label>
          <input
            type="text"
            value={name}
            onChange={e => setName(e.target.value)}
          />
        </div>
        <div>
          <label>Email:</label>
          <input
            type="email"
            value={email}
            onChange={e => setEmail(e.target.value)}
          />
        </div>
        <div>
          <label>Senha:</label>
          <input
            type="password"
            value={password}
            onChange={e => setPassword(e.target.value)}
          />
        </div>
        <button type="submit">Criar</button>
      </form>
    </div>
  );
}

export default CreateUser;

import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function CreateProduct() {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [price, setPrice] = useState('');
  const navigate = useNavigate(); // Substitua useHistory por useNavigate

  const handleSubmit = (event) => {
    event.preventDefault();

    axios.post(`${process.env.REACT_APP_API_URL}/api/Product`, { name, description, price })
      .then(response => {
        console.log('Product created:', response.data);
        navigate('/'); // Use navigate ao invés de history.push
      })
      .catch(error => console.error('Error creating Product:', error));
  };

  return (
    <div>
      <h1>Criar Novo Produto</h1>
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
          <label>Description:</label>
          <input
            type="description"
            value={description}
            onChange={e => setDescription(e.target.value)}
          />
        </div>
        <div>
          <label>Preço:</label>
          <input
            type="price"
            value={price}
            onChange={e => setPrice(e.target.value)}
          />
        </div>
        <button type="submit">Criar</button>
      </form>
    </div>
  );
}

export default CreateProduct;

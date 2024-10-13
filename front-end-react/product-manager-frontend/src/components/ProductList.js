import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

function ProductList() {
  const [Products, setProducts] = useState([]);

  useEffect(() => {
    axios.get(`${process.env.REACT_APP_API_URL}/api/Product`)
      .then(response => setProducts(response.data))
      .catch(error => console.error('Error fetching Products:', error));
  }, []);

  return (
    <div>
      <h1>Lista de Produtos</h1>
      <ul>
        {Products.map(Product => (
          <li key={Product.id}>
            <Link to={`/Product/${Product.id}`}>{Product.name}</Link>
          </li>
        ))}
      </ul>
      <Link to="/create-Product">Criar Produto</Link>
    </div>
  );
}

export default ProductList;

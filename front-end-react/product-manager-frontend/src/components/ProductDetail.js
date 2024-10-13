import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams } from 'react-router-dom';

function ProductDetail() {
  const { id } = useParams();
  const [Product, setProduct] = useState(null);

  useEffect(() => {
    axios.get(`${process.env.REACT_APP_API_URL}/api/Product/${id}`)
      .then(response => setProduct(response.data))
      .catch(error => console.error('Error fetching Product:', error));
  }, [id]);

  if (!Product) {
    return <div>Carregando...</div>;
  }

  return (
    <div>
      <h1>Detalhes do Produto</h1>
      <p>Nome: {Product.name}</p>
      <p>Description: {Product.description}</p>
    </div>
  );
}

export default ProductDetail;

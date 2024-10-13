import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import ProductList from './components/ProductList';
import ProductDetail from './components/ProductDetail';
import CreateProduct from './components/CreateProduct';

function App() {
  return (
    <Router>
      <div className="App">
        <Routes>
          <Route exact path="/" element={<ProductList />} />
          <Route path="/Product/:id" element={<ProductDetail />} />
          <Route path="/create-Product" element={<CreateProduct />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;

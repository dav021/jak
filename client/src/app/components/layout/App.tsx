import React, { useState, useEffect } from "react";
import { Product } from "../../models/product";
import AddProductForm from "../../../features/products/AddProductForm";
import ProductsList from "../../../features/products/ProductList";
import { addProduct, deleteProduct, getProducts } from "../../../service/ProductService";

const App: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  

  // Simuler un chargement initial de produits
  useEffect(() => {
    loadProducts()
  }, []);

  const loadProducts = async () => {
    try {
      setLoading(true);
      const data = await getProducts();
      setProducts(data);
      setError(null);
    } catch (err) {
      setError("Failed to load products");
      console.error("Error loading products:", err);
    } finally {
      setLoading(false);
    }
  };

  const handleAddProduct = async (product: Omit<Product, "id">) => {
    try {
      setLoading(true);
      const newProduct = await addProduct(product);
      setProducts([...products, newProduct]);
      setError(null);
    } catch (err) {
      setError("Failed to add product");
      console.error("Error adding product:", err);
    } finally {
      setLoading(false);
    }
  };


  const handleDeleteProduct = async (id: number) => {
    try {
      setLoading(true);
      await deleteProduct(id.toString());
      setProducts(products.filter((product) => product.id !== id));
      setError(null);
    } catch (err) {
      setError("Failed to delete product");
      console.error("Error deleting product:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container mx-auto p-4">
      <h1 className="text-3xl font-bold mb-8 text-blue-500">Product Management</h1>
      <AddProductForm onAdd={handleAddProduct} isLoading={loading} />
      <ProductsList products={products} onDelete={handleDeleteProduct} isLoading={loading} />
    </div>
  );
};

export default App;
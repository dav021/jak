import React, { useState } from "react";
import { Product } from "../../app/models/product";

interface AddProductFormProps {
  onAdd: (product: Omit<Product, "id">) => void;
  isLoading: boolean;
}

const AddProductForm: React.FC<AddProductFormProps> = ({ onAdd, isLoading }) => {
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [error, setError] = useState<string | null>(null);

  const validateForm = (): boolean => {
    if (!name.trim()) {
      setError("Name is required");
      return false;
    }
    
    const priceValue = parseFloat(price);
    if (isNaN(priceValue) || priceValue <= 0) {
      setError("Price must be a positive number");
      return false;
    }

    return true;
  };

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError(null);

    if (!validateForm()) {
      return;
    }

    try {
      onAdd({ name: name.trim(), price: parseFloat(price) });
      setName("");
      setPrice("");
    } catch (err) {
      setError(err instanceof Error ? err.message : "Failed to add product");
    }
  };

  return (
    <form onSubmit={handleSubmit} className="p-4 bg-white rounded-lg shadow-sm">
      <h2 className="text-2xl font-bold mb-4">Add Product</h2>
      {error && (
        <div className="mb-4 p-3 bg-red-50 border border-red-200 text-red-600 rounded-md text-sm">
          {error}
        </div>
      )}
      <div className="mb-4">
        <label className="block text-sm font-medium mb-2">Name:</label>
        <input
          type="text"
          value={name}
          onChange={(e) => {
            setName(e.target.value);
            setError(null);
          }}
          className="w-full p-2 border rounded focus:ring-2 focus:ring-green-500 focus:border-green-500"
          required
          disabled={isLoading}
        />
      </div>
      <div className="mb-4">
        <label className="block text-sm font-medium mb-2">Price:</label>
        <input
          type="number"
          value={price}
          onChange={(e) => {
            setPrice(e.target.value);
            setError(null);
          }}
          className="w-full p-2 border rounded focus:ring-2 focus:ring-green-500 focus:border-green-500"
          required
          min="0.01"
          step="0.01"
          disabled={isLoading}
        />
      </div>
      <button
        type="submit"
        className="bg-green-500 text-white px-4 py-2 rounded hover:bg-green-600 disabled:opacity-70 disabled:cursor-not-allowed inline-flex items-center space-x-2"
        disabled={isLoading}
      >
         Add Product
      </button>
    </form>
  );
};

export default AddProductForm;
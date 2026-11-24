// API data services. This file only communicates with the server.

const baseUrl = "http://localhost:5163/api";

export const fetchRestaurants = async () => {
  const response = await fetch(`${baseUrl}/restaurant`);

  if (!response.ok) {
    throw new Error(`GET failed: ${response.status}`);
  }

  const data = await response.json();
  return data;
};


export const fetchCategories = async () => {
  const response = await fetch(`${baseUrl}/categories`);

  if (!response.ok) {
    throw new Error(`GET failed: ${response.status}`);
  }

  const data = await response.json();
  return data;
};


export const fetchMenuItems = async () => {
  const response = await fetch(`${baseUrl}/menu`);

  if (!response.ok) {
    throw new Error(`GET failed: ${response.status}`);
  }

  const data = await response.json();
  return data;
};


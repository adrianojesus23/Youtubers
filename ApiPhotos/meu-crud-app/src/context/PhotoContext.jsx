import React, { createContext, useState, useEffect } from 'react';
import PhotoService from '../services/PhotoService';

export const PhotoContext = createContext();

export const PhotoProvider = ({ children }) => {
    const [photos, setPhotos] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        PhotoService.getPhotos().then((response) => {
            // Ordena os dados por ID de forma decrescente
            const sortedPhotos = response.data.sort((a, b) => b.id - a.id);
            setPhotos(sortedPhotos);
            setLoading(false);
        });
    }, []);

    return (
        <PhotoContext.Provider value={{ photos, setPhotos, loading }}>
            {children}
        </PhotoContext.Provider>
    );
};

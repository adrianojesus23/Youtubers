import React, {useState, useEffect, useContext} from 'react';
import PhotoService from "../../services/PhotoService";
import { useNavigate, useParams } from 'react-router-dom';
import {PhotoContext} from "../../context/PhotoContext";

const PhotoForm = () => {
    const [title, setTitle] = useState('');
    const [url, setUrl] = useState('');
    const [thumbnailUrl, setThumbnailUrl] = useState('');
    const { id } = useParams(); // Para editar um foto
    const navigate = useNavigate();
    const { photos, setPhotos } = useContext(PhotoContext);

    useEffect(() => {
        if (id) {
            // Se há um ID, busque a foto para editar
            PhotoService.getPhotoById(id).then(response => {
                const { title, url, thumbnailUrl } = response.data;
                setTitle(title);
                setUrl(url);
                setThumbnailUrl(thumbnailUrl);
            });
        }
    }, [id]);

    const handleSubmit =  (e) => {
        e.preventDefault();
        const newPhoto = { title, url, thumbnailUrl };

        if (id) {
            // Se o ID existir, atualize a foto
             PhotoService.updatePhoto(id, newPhoto).then(() => {
                navigate('/');
            });
        } else {
            // Caso contrário, crie uma nova foto

            PhotoService.createPhoto(newPhoto, setPhotos).then(() => {
                debugger
                console.table(photos); // Log the new photo details
                navigate('/'); // Redireciona após a criação
            }).catch(error => {
                console.error("Failed to create photo:", error); // Handle error
            });
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>Title</label>
            <input type="text" value={title} onChange={(e) => setTitle(e.target.value)} />
            <label>URL</label>
            <input type="text" value={url} onChange={(e) => setUrl(e.target.value)} />
            <label>Thumbnail URL</label>
            <input type="text" value={thumbnailUrl} onChange={(e) => setThumbnailUrl(e.target.value)} />
            <button type="submit">{id ? 'Update Photo' : 'Add Photo'}</button>
        </form>
    );
};

export default PhotoForm;

import React from 'react';
import { Link } from 'react-router-dom';
import PhotoService from '../../services/PhotoService';

const PhotoItem = ({ photo, onDelete }) => {
    const handleDelete = () => {
        PhotoService.deletePhoto(photo.id).then(() => {
            onDelete(photo.id);
        });
    };

    return (
        <tr>
            <td>{photo.id}</td>
            <td>{photo.title}</td>
            <td><img src={photo.thumbnailUrl} alt={photo.title} style={{ width: '50px', height: '50px' }} /></td>
            <td>
                <Link to={`/edit/${photo.id}`}>Edit</Link> | <button onClick={handleDelete}>Delete</button>
            </td>
        </tr>
    );
};

export default PhotoItem;

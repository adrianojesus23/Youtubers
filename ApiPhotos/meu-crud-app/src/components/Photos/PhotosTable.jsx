import React, { useContext, useState } from 'react';
import { PhotoContext } from '../../context/PhotoContext';
import PhotoItem from "./PhotoItem";
import '../../pagination.css'
const PhotosTable = () => {
    const { photos, setPhotos, loading } = useContext(PhotoContext);
    const [searchTerm, setSearchTerm] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const photosPerPage = 5; // Número de fotos por página

    // Filtrar fotos com base no termo de pesquisa
    const filteredPhotos = photos.filter(photo =>
        photo.title.toLowerCase().includes(searchTerm.toLowerCase())
    );

    // Calcular o número total de páginas
    const totalPages = Math.ceil(filteredPhotos.length / photosPerPage);

    // Obter as fotos para a página atual
    const indexOfLastPhoto = currentPage * photosPerPage;
    const indexOfFirstPhoto = indexOfLastPhoto - photosPerPage;
    const currentPhotos = filteredPhotos.slice(indexOfFirstPhoto, indexOfLastPhoto);

    const handleDelete = (id) => {
        // Remover a foto do estado local
        setPhotos(photos.filter((photo) => photo.id !== id));
    };

    const handlePageChange = (page) => {
        setCurrentPage(page);
    };

    if (loading) {
        return <p>Loading...</p>;
    }

    return (
        <div>
            <input
                type="text"
                placeholder="Search by title..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
            />
            <table className="table">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Title</th>
                    <th>Thumbnail</th>
                    <th>Actions</th>
                </tr>
                </thead>
                <tbody>
                {currentPhotos.map((photo) => (
                    <PhotoItem key={photo.id} photo={photo} onDelete={handleDelete} />
                ))}
                </tbody>
            </table>
            {/* Paginação */}
            <div className="pagination">
                {Array.from({ length: totalPages }, (_, index) => (
                    <button
                        key={index + 1}
                        onClick={() => handlePageChange(index + 1)}
                        disabled={currentPage === index + 1}
                    >
                        {index + 1}
                    </button>
                ))}
            </div>
        </div>
    );
};

export default PhotosTable;

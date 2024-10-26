import axios from 'axios';


const API_URL = 'https://jsonplaceholder.typicode.com/photos';

const PhotoService = {
    getPhotos: () => axios.get(API_URL),
    getPhotoById: (id) => axios.get(`${API_URL}/${id}`),
    createPhoto: (photo, setPhotos) =>
        axios.post(API_URL, photo)
            .then(response => {
                debugger
                // Adiciona a nova foto ao estado
                setPhotos(prevPhotos => [...prevPhotos, response.data]);
                console.log(response.data);
            })
            .catch(error => {
                console.error(error);
            }),
    updatePhoto: (id, photo) => axios.put(`${API_URL}/${id}`, photo),
    deletePhoto: (id) => axios.delete(`${API_URL}/${id}`),
};

export default PhotoService;

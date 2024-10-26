// import React from 'react';
// import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
// import Navbar from "./components/Photos/Navbar";
// import {PhotoProvider} from "./context/PhotoContext";
// import PhotosTable from "./components/Photos/PhotosTable";
// import PhotoForm from "./components/Photos/PhotoForm"; // Atualizado para Routes
//
//
// const App = () => {
//     return (
//         <PhotoProvider>
//             <Router>
//                 <Navbar />
//                 <div className="container">
//                     <Routes>
//                         <Route path="/" element={<PhotosTable />} /> {/* Atualizado para element */}
//                         <Route path="/add" element={<PhotoForm />} /> {/* Atualizado para element */}
//                         {/* Adicione mais rotas conforme necessário */}
//                     </Routes>
//                 </div>
//             </Router>
//         </PhotoProvider>
//     );
// };
//
// export default App;

import './App.css'
import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Navbar from "./components/Photos/Navbar";
import { PhotoProvider } from "./context/PhotoContext";
import PhotosTable from "./components/Photos/PhotosTable";
import PhotoForm from "./components/Photos/PhotoForm";

const App = () => {
    return (
        <PhotoProvider>
            <Router>
                <Navbar />
                <div className="container">
                    <Routes>
                        <Route path="/" element={<PhotosTable />} />
                        <Route path="/add" element={<PhotoForm />} />
                        <Route path="/edit/:id" element={<PhotoForm />} /> {/* Rota para editar */}
                    </Routes>
                </div>
            </Router>
        </PhotoProvider>
    );
};

export default App;


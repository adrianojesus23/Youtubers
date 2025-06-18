import React, {useState, useEffect} from 'react'
import Search from './components/Search.jsx'
const API_BASE_URL = "https://api.themoviedb.org/3";
const API_KEY = import.meta.env.VITE_TMDB_API_KEY;
import Spinner from './components/Spinner.jsx'
import MovieCard from './components/MovieCard.jsx'

const API_OPTIONS = {
    method: 'GET',
    headers: {
        accept: 'application/json',
        Authorization: `Bearer ${API_KEY}`
    }
}

const App = () => {

    const [searchTerm, setSearchTerm] = useState('');
    const [errorMessage, setErrorMessage] = useState('')
    const [movies, setMovies] = useState([]);
    const [isLoading, setIsLoading] = useState(false);

    const fetchMovies = async (query = '') => {

        setIsLoading(true);
        setErrorMessage('');
        try{
            //https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc
         const endpoint = query? `${API_BASE_URL}/search/movie?query=${encodeURIComponent(query)}`:
                                 `${API_BASE_URL}/discover/movie?include_adult=false&include_video=false&language=en-US&page=1&sort_by=popularity.desc`;

         const response = await fetch(endpoint, API_OPTIONS);
         const data = await response.json();
         console.log(data);
           //throw new Error('Error fetching movies');
            if(!response.ok){
                throw new Error(`Error fetching movies. Status: ${response.status}`);
            }

            if(data?.response === 'False'){
                setErrorMessage(data.Error || 'Failed tofetch movies');
                setMovies([]);
                return;
            }
            setMovies(data?.results || []);
        }catch(error){
            console.error(`Fetch error movies: ${error}`);
            setErrorMessage(`Error fetching movies. Please try again later. ${error}`);
        }finally{
            setIsLoading(false);
        }
    }

    useEffect(() => {
        fetchMovies(searchTerm);
    }, [searchTerm]);

    return (
      <main>
      <div className="pattern">

      </div>

          <div className="wrapper">
           <header>
               <img src="https://img.icons8.com/ios-glyphs/60/000000/youtube.png"/>
               <h1>Find <span className="text-gradient">Movies</span> You'll Enjoy Without the Hassle</h1>
               <Search searchTerm={searchTerm} setSearchTerm={setSearchTerm}/>
               <h4 className="text-white">{searchTerm}</h4>
           </header>
              <section className="all-movies">
                  <h2 className="mt-[40px]">All Movies</h2>
                  {isLoading ? (
                      //<p className="text-white">Loading...</p>
                      <Spinner/>
                  ) : errorMessage ? (
                      <p className="text-red-500">{errorMessage}</p>
                  ) : (
                      <ul>
                          {movies.map((movie) => (
                              <li key={movie.id} className="text-white">
                                  <MovieCard key={movie.id} movie={movie} />
                              </li>
                          ))}
                      </ul>
                  )}
              </section>

          </div>
      </main>
    )
}
export default App

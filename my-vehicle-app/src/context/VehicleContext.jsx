import mockVehicles from "../mock";
import React,{Children, createContext, useContext, useReducer} from "react";

const VehicleContext = createContext();
const initialState = {
    vehicles: mockVehicles,
}

const reducer = (state, action) => {
    switch (action.type) {
        case "ADD_Vehicle":
            return {...state, vehicles: [...state.vehicles, action.payload]};
        case "DELETE_Vehicle":
            return {
                ...state, vehicles: state.vehicles.filter(v =>
                    v.id !== action.payload)
            };
        case "TOGGLE_Vehicle":
            return {
                ...state,
                vehicles: state.vehicles.map(v => v.id === action.payload ?
                    {...v, completed: !v.completed} : v)
            };
        default:
            return state;
    }
}

export const VehicleProvider = ({children}) => {

    const [state, dispatch] = useReducer(reducer, initialState);
    return (
        <VehicleContext.Provider value={{state, dispatch}}>
            {children}
        </VehicleContext.Provider>
    );
}

export const useVehicleContext = () =>
    useContext(VehicleContext);
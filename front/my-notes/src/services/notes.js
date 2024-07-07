import axios from "axios"

export const fetchNotes = async (filter) => {
    let response = null;
    try{
        response = await axios.get("http://localhost:5097/notes", {
            params:
            {
                search: filter?.search,
                sortItem: filter?.sortItem,
                sortOrder: filter?.sortOrder,
            },
        });
    }
    catch(e)
    {
        console.log.console.error(e);
    }

    console.log(response);

    return response.data.notes;
};


export const createNote = async (note) => {
    let response = null;
    try{
        response = await axios.post("http://localhost:5097/notes", note);
    }
    catch(e)
    {
        console.log.console.error(e);
    }

    console.log("noteCreated");

    return response.status;
};
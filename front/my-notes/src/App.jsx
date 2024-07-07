import CreateNoteForm from './components/CreateNoteForm'
import Note from './components/Note'
import Filters from './components/Filters'
import { useEffect, useState } from 'react'
import { fetchNotes, createNote} from './services/notes'

function App() {

    const [notes, setNotes] = useState([]);
    const [filter, setFilter] = useState(
        {
            search: "",
            sortItem: "date",
            sortOrder: "desc",
        }
    )

    useEffect(() => {
        const fetchData = async () => {
            let res = await fetchNotes(filter);
            setNotes(res);
        }
        fetchData();
    }, [filter]);

    const onCreate = async (note) => {
        await createNote(note);
        let res = await fetchNotes(filter);
        setNotes(res);
    }

    return (
        <section className='p-8 flex flex-row justify-start items-start gap-12'>
            <div className='flex flex-col w-1/3 gap-10'>
                <CreateNoteForm onCreate={onCreate} />
                <Filters filter={filter} setFilter={setFilter} />
            </div>

            <ul className='flex flex-col gap-5 w-1/2'>

                {notes.map((n) =>
                    <li key={n.id}>
                        <Note name={n.name} text={n.description} date={n.createdDate} />
                    </li>
                )}

            </ul>
        </section>
    )
}

export default App
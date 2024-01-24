import '@mantine/core/styles.css';

import { MantineProvider } from '@mantine/core';
import './App.css';
import TasksContainer from './components/TasksContainer';

function App() {


  return (
    <MantineProvider>
      <TasksContainer title='Todo'/>
    </MantineProvider>
    
  )
}

export default App

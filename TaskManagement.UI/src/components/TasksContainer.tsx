import { ActionIcon, Badge, Flex, ScrollArea, Stack, Text } from "@mantine/core"
import '../App.css'
import { BsThreeDots } from "react-icons/bs";
interface TasksContainerProps {
    title: string;
}

const TasksContainer = (props: TasksContainerProps) => {
    const { title } = props;
    let stringArray = [
        "Apple",
        "Banana",
        "Cherry",
        "Date",
        "Elderberry",
        "Fig",
        "Grape",
        "Honeydew",
        "Iguana",
        "Jackfruit",
        "Kiwi",
        "Lemon",
        "Mango",
        "Nectarine",
        "Orange",
        "Papaya",
        "Quince",
        "Raspberry",
        "Strawberry",
        "Tomato",
        "Umbrella",
        "Vanilla",
        "Watermelon",
        "Xylophone",
        "Yogurt",
        "Zucchini",
        "Aardvark",
        "Bear",
        "Cat",
        "Dog",
        "Elephant",
        "Fox",
        "Giraffe",
        "Horse",
        "Iguana",
        "Jaguar",
        "Kangaroo",
        "Lion",
        "Monkey",
        "Nightingale",
        "Ostrich",
        "Penguin",
        "Quokka",
        "Raccoon",]
    return (
        <Stack className="task-container">
            <Flex justify={'space-between'} m={'sm'} align='center'>
                <Flex m={'sm'} justify='center' align='center' >
                    <Badge size="xs" circle style={{backgroundColor:"rgb(218, 251, 225)",borderColor:"rgb(31, 136, 61)",borderWidth:2}}></Badge>
                    <Text size="md" mx={'sm'} fw={600}>{title}</Text>
                    <Badge  color="rgba(175, 184, 193, 0.2)" ><Text size="xs" className="badge-num">{stringArray.length}</Text></Badge>
                </Flex>
                <ActionIcon variant="default" className="icon-btn">
                    <BsThreeDots />
                </ActionIcon>
            </Flex>
             <ScrollArea className="scroll">
                {stringArray.map(item => <div>{item}</div>)}
            </ScrollArea>
        </Stack>
    )
}

export default TasksContainer
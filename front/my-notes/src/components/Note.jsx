import { Card, CardBody, CardFooter, CardHeader, Divider, Heading, Text } from '@chakra-ui/react'
import moment from 'moment/moment';

export default function Note({name, text, date}) {
    return (
        <Card variant={"filled"}>
            <CardHeader>
                <Heading size={"md"}>{name}</Heading>
            </CardHeader>
            <Divider borderColor={'gray'}></Divider>
            <CardBody>
                <Text>{text}</Text>
            </CardBody>
            <Divider borderColor={'gray'}></Divider>
            <CardFooter>
                {moment(date).format("DD/MM/YYYY h:mm:ss")}
            </CardFooter>
        </Card>
    );
}
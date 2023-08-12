<script lang="ts">
	import Registration from '../../components/login/registration.svelte';

	function onUserCreated() {
		console.log('User created!');
	}
</script>

<Registration {onUserCreated} />
